#!/usr/bin/env python3
import argparse
import json
import re
import sys
import zipfile
from collections import Counter
from pathlib import Path
from xml.etree import ElementTree as ET

W_NS = "http://schemas.openxmlformats.org/wordprocessingml/2006/main"
NS = {"w": W_NS}


def qn(tag: str) -> str:
    return f"{{{W_NS}}}{tag}"


def paragraph_text(para: ET.Element) -> str:
    return "".join(node.text or "" for node in para.findall(".//w:t", NS)).strip()


def first_style_id(para: ET.Element, tag: str) -> str | None:
    style = para.find(f".//w:{tag}", NS)
    if style is None:
      return None
    return style.attrib.get(qn("val"))


def read_zip_xml(zf: zipfile.ZipFile, name: str) -> ET.Element | None:
    try:
        return ET.fromstring(zf.read(name))
    except KeyError:
        return None


def inspect(path: Path) -> dict:
    with zipfile.ZipFile(path) as zf:
        document = read_zip_xml(zf, "word/document.xml")
        if document is None:
            raise SystemExit("word/document.xml not found")

        paragraphs = document.findall(".//w:body/w:p", NS)
        tables = document.findall(".//w:tbl", NS)
        headings = []
        para_styles = Counter()
        run_styles = Counter()
        all_text = []

        for para in paragraphs:
            text = paragraph_text(para)
            if text:
                all_text.append(text)
            p_style = first_style_id(para, "pStyle")
            if p_style:
                para_styles[p_style] += 1
                if p_style.lower().startswith("heading"):
                    headings.append({"style": p_style, "text": text[:120]})
            for run_style in para.findall(".//w:rStyle", NS):
                style_id = run_style.attrib.get(qn("val"))
                if style_id:
                    run_styles[style_id] += 1

        full_text = "\n".join(all_text)
        placeholders = sorted(set(re.findall(r"\{\{[^{}]+\}\}|<<[^<>]+>>", full_text)))

        comments = read_zip_xml(zf, "word/comments.xml")
        footnotes = read_zip_xml(zf, "word/footnotes.xml")
        endnotes = read_zip_xml(zf, "word/endnotes.xml")

        tracked_changes = (
            len(document.findall(".//w:ins", NS))
            + len(document.findall(".//w:del", NS))
            + len(document.findall(".//w:moveFrom", NS))
            + len(document.findall(".//w:moveTo", NS))
        )

        result = {
            "file": str(path),
            "parts": sorted(zf.namelist()),
            "paragraph_count": len(paragraphs),
            "table_count": len(tables),
            "section_count": len(document.findall(".//w:sectPr", NS)),
            "heading_count": len(headings),
            "headings": headings[:25],
            "paragraph_styles_in_use": para_styles.most_common(20),
            "run_styles_in_use": run_styles.most_common(20),
            "placeholder_count": len(placeholders),
            "placeholders": placeholders[:50],
            "comment_count": 0 if comments is None else len(comments.findall(".//w:comment", NS)),
            "footnote_count": 0 if footnotes is None else len(footnotes.findall(".//w:footnote", NS)),
            "endnote_count": 0 if endnotes is None else len(endnotes.findall(".//w:endnote", NS)),
            "tracked_change_elements": tracked_changes,
        }
        return result


def main() -> int:
    parser = argparse.ArgumentParser()
    parser.add_argument("path")
    parser.add_argument("--json", action="store_true")
    args = parser.parse_args()

    result = inspect(Path(args.path))
    if args.json:
        json.dump(result, sys.stdout, ensure_ascii=False, indent=2)
        print()
        return 0

    print(f"File: {result['file']}")
    print(f"Paragraphs: {result['paragraph_count']}")
    print(f"Tables: {result['table_count']}")
    print(f"Sections: {result['section_count']}")
    print(f"Comments: {result['comment_count']}")
    print(f"Footnotes: {result['footnote_count']}")
    print(f"Endnotes: {result['endnote_count']}")
    print(f"Tracked change elements: {result['tracked_change_elements']}")
    print("Paragraph styles in use:")
    for style, count in result["paragraph_styles_in_use"]:
        print(f"  {style}: {count}")
    print("Headings:")
    for heading in result["headings"]:
        print(f"  [{heading['style']}] {heading['text']}")
    if result["placeholders"]:
        print("Placeholders:")
        for token in result["placeholders"]:
            print(f"  {token}")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
