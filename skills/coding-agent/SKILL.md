---
name: coding-agent
description: 'Delegate coding tasks to Gemini, Codex, Claude Code, or Pi agents via background process. Use when: (1) building/creating new features or apps, (2) reviewing PRs (spawn in temp dir), (3) refactoring large codebases, (4) iterative coding that needs file exploration. NOT for: simple one-liner fixes (just edit), reading code (use read tool), thread-bound ACP harness requests in chat (for example spawn/run Gemini or Claude Code in a Discord thread; use sessions_spawn with runtime:"acp"), or any work in ~/clawd workspace (never spawn agents here). Claude Code: use --print --permission-mode bypassPermissions (no PTY). Gemini/Codex/Pi/OpenCode: pty:true required.'
metadata:
  {
    "openclaw": { "emoji": "🧩", "requires": { "anyBins": ["gemini", "claude", "codex", "opencode", "pi"] } },
  }
---

# Coding Agent (bash-first)

Use **bash** (with optional background mode) for all coding agent work. Simple and effective.

## ⚠️ PTY Mode: Gemini/Codex/Pi/OpenCode yes, Claude Code no

For **Gemini, Codex, Pi, and OpenCode**, PTY is required (interactive terminal apps):

```bash
# ✅ Correct for Gemini/Codex/Pi/OpenCode
bash pty:true command:"gemini 'Your prompt'"
```

For **Claude Code** (`claude` CLI), use `--print --permission-mode bypassPermissions` instead.

### Bash Tool Parameters

| Parameter    | Type    | Description                                                                 |
| ------------ | ------- | --------------------------------------------------------------------------- |
| `command`    | string  | The shell command to run                                                    |
| `pty`        | boolean | **Use for coding agents!** Allocates a pseudo-terminal for interactive CLIs |
| `workdir`    | string  | Working directory (agent sees only this folder's context)                   |
| `background` | boolean | Run in background, returns sessionId for monitoring                         |

---

## Quick Start: One-Shot Tasks

For quick prompts/chats in a real project - with PTY!

```bash
# Recommended Default: Gemini CLI
bash pty:true workdir:~/Projects/myproject command:"gemini 'Add error handling to the API calls'"

# Alternative: Codex CLI
bash pty:true workdir:~/Projects/myproject command:"codex exec 'Add error handling to the API calls'"
```

---

## Gemini CLI (Default)

**Model:** `gemini-1.5-pro` (or as configured in your gemini-cli settings)

### Usage

```bash
# Quick one-shot - remember PTY!
bash pty:true workdir:~/project command:"gemini 'Build a dark mode toggle'"

# Background for longer work
bash pty:true workdir:~/project background:true command:"gemini 'Refactor the auth module'"
```

---

## Codex CLI

**Model:** `gpt-5.3-codex` is the default (set in ~/.codex/config.toml)

### Flags

| Flag            | Effect                                             |
| --------------- | -------------------------------------------------- |
| `exec "prompt"` | One-shot execution, exits when done                |
| `--full-auto`   | Sandboxed but auto-approves in workspace           |
| `--yolo`        | NO sandbox, NO approvals (fastest, most dangerous) |

---

## Claude Code

```bash
# Foreground
bash workdir:~/project command:"claude --permission-mode bypassPermissions --print 'Your task'"
```

---

## ⚠️ Rules

1. **Use the right execution mode per agent**:
   - Gemini/Codex/Pi/OpenCode: `pty:true`
   - Claude Code: `--print --permission-mode bypassPermissions` (no PTY required)
2. **Respect tool choice** - if user asks for Gemini, use Gemini.
3. **--full-auto / --yolo** - Use these when using Codex for faster, automated building.
4. **NEVER start agents in ~/.openclaw/** - it might read sensitive system configs!

---

## Progress Updates (Critical)

When you spawn coding agents in the background, keep the user in the loop.

- Send 1 short message when you start (what's running + where).
- Update again when the agent finishes (include what changed + where).

---

## Auto-Notify on Completion

For long-running background tasks, append a wake trigger to your prompt:

```bash
bash pty:true workdir:~/project background:true command:"gemini 'Build a REST API for todos.

When completely finished, run: openclaw system event --text \"Done: Built todos REST API with CRUD endpoints\" --mode now'"
```
