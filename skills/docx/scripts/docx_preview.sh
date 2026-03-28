#!/usr/bin/env bash
set -euo pipefail

usage() {
  echo "Usage: $(basename "$0") <file.docx>"
  exit 1
}

[ $# -ge 1 ] || usage

input="$1"

if [ ! -f "$input" ]; then
  echo "Error: file not found: $input" >&2
  exit 1
fi

echo "=== DOCX Preview: $(basename "$input") ==="
du -h "$input" | awk '{print "File size: " $1}'

if command -v pandoc >/dev/null 2>&1; then
  content="$(pandoc -f docx -t plain "$input" 2>/dev/null || true)"
  if [ -n "$content" ]; then
    words="$(printf '%s\n' "$content" | wc -w | tr -d ' ')"
    echo "Word count: $words"
    echo "---"
    printf '%s\n' "$content"
    exit 0
  fi
fi

echo "(pandoc unavailable or failed; falling back to XML text extraction)"
echo "---"
python3 - "$input" <<'PY'
import re
import sys
import zipfile
from xml.etree import ElementTree as ET

path = sys.argv[1]
ns = {"w": "http://schemas.openxmlformats.org/wordprocessingml/2006/main"}

with zipfile.ZipFile(path) as zf:
    data = zf.read("word/document.xml")

root = ET.fromstring(data)
lines = []
for para in root.findall(".//w:body/w:p", ns):
    texts = [t.text or "" for t in para.findall(".//w:t", ns)]
    line = "".join(texts).strip()
    if line:
        lines.append(re.sub(r"\s+", " ", line))

print("\n".join(lines[:200]))
PY
