#!/usr/bin/env bash
set -euo pipefail

echo "=== docx skill environment check ==="

status=0

check_bin() {
  local name="$1"
  local required="${2:-yes}"
  if command -v "$name" >/dev/null 2>&1; then
    printf "[OK]   %s\n" "$name"
  else
    if [ "$required" = "yes" ]; then
      printf "[MISS] %s (required)\n" "$name"
      status=1
    else
      printf "[WARN] %s (optional)\n" "$name"
    fi
  fi
}

check_bin dotnet yes
check_bin tiwater-docx yes
check_bin python3 yes
check_bin unzip yes
check_bin pandoc no

if [ $status -eq 0 ]; then
  echo "READY"
else
  echo "NOT READY"
fi

exit $status
