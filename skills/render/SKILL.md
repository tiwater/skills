---
name: render
description: "Render cloud platform — manage services, deployments, and access logs via the Render API. Built for AI agents — Python stdlib only, zero dependencies. Use for deployment monitoring and error log retrieval."
homepage: https://www.agxntsix.ai
license: MIT
compatibility: Python 3.10+ (stdlib only — no dependencies)
metadata: {"openclaw": {"emoji": "🚀", "requires": {"env": ["RENDER_API_KEY", "RENDER_WORKSPACE_ID"]}, "primaryEnv": "RENDER_API_KEY", "homepage": "https://www.agxntsix.ai"}}
---

# 🚀 Render

Render cloud platform — manage services and deployments via the Render API.

## Features

- **Service management** — list and get service details
- **Deployment tracking** — deploy history and status
- **Logs** — access service build and app logs via API

## Requirements

| Variable | Required | Description |
|----------|----------|-------------|
| `RENDER_API_KEY` | ✅ | API key for Render |
| `RENDER_WORKSPACE_ID` | ✅ | Workspace/Owner ID for logs |

## Commands

### `services`
List services.
```bash
python3 {baseDir}/scripts/render.py services --limit 20
```

### `service-get`
Get service details.
```bash
python3 {baseDir}/scripts/render.py service-get srv-abc123
```

### `deploys`
List deployments.
```bash
python3 {baseDir}/scripts/render.py deploys srv-abc123 --limit 10
```

### `logs`
Get service logs (default type: build).
```bash
python3 {baseDir}/scripts/render.py logs srv-abc123 --limit 50 --type build
```

## Output Format

All commands output JSON by default. Add `--human` for readable formatted output.

## Credits
---
Built by [M. Abidi](https://www.linkedin.com/in/mohammad-ali-abidi) | Updated for correct API usage by Gemini CLI.
Part of the **AgxntSix Skill Suite** for OpenClaw agents.
