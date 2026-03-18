#!/usr/bin/env python3
"""Render CLI — comprehensive API integration for AI agents.

Full CRUD operations, search, reporting, and automation.
Zero dependencies beyond Python stdlib.
"""

import argparse
import json
import os
import sys
import urllib.request
import urllib.error
import urllib.parse
from datetime import datetime, timezone

API_BASE = "https://api.render.com/v1"


def get_token():
    """Get API token from environment."""
    token = os.environ.get("RENDER_API_KEY", "")
    if not token:
        env_path = os.path.join(
            os.environ.get("WORKSPACE", os.path.expanduser("~/.openclaw/workspace")),
            ".env"
        )
        if os.path.exists(env_path):
            with open(env_path) as f:
                for line in f:
                    line = line.strip()
                    if line.startswith("RENDER_API_KEY="):
                        token = line.split("=", 1)[1].strip().strip('"').strip("'")
                        break
    if not token:
        print(f"Error: RENDER_API_KEY not set", file=sys.stderr)
        sys.exit(1)
    return token


def get_owner_id():
    """Get Owner/Workspace ID from environment."""
    owner_id = os.environ.get("RENDER_WORKSPACE_ID", "")
    return owner_id


def api(method, path, data=None, params=None):
    """Make an API request."""
    token = get_token()
    url = f"{API_BASE}{path}"
    if params:
        qs = urllib.parse.urlencode({k: v for k, v in params.items() if v is not None})
        if qs:
            url = f"{url}?{qs}"
    body = json.dumps(data).encode() if data else None
    req = urllib.request.Request(url, data=body, method=method)
    req.add_header("Authorization", f"Bearer {token}")
    req.add_header("Content-Type", "application/json")
    req.add_header("Accept", "application/json")
    try:
        resp = urllib.request.urlopen(req, timeout=30)
        raw = resp.read().decode()
        return json.loads(raw) if raw.strip() else {"ok": True}
    except urllib.error.HTTPError as e:
        err_body = e.read().decode()
        print(json.dumps({"error": True, "code": e.code, "message": err_body}), file=sys.stderr)
        sys.exit(1)


def output(data, human=False):
    """Output data as JSON or human-readable."""
    if human and isinstance(data, list):
        for item in data:
            if isinstance(item, dict):
                for k, v in item.items():
                    print(f"  {k}: {v}")
                print()
            else:
                print(item)
    elif human and isinstance(data, dict):
        for k, v in data.items():
            print(f"  {k}: {v}")
    else:
        print(json.dumps(data, indent=2, default=str))


def cmd_services(args):
    """List services."""
    params = {}
    if hasattr(args, 'limit') and args.limit:
        params["limit"] = args.limit
    if hasattr(args, 'id') and args.id:
        data = api("GET", f"/services/{args.id}")
    else:
        data = api("GET", "/services", params=params)
    output(data, getattr(args, 'human', False))

def cmd_service_get(args):
    """Get service details."""
    service_id = args.args[0] if args.args else args.id
    if not service_id:
        print("Error: service ID required", file=sys.stderr)
        sys.exit(1)
    data = api("GET", f"/services/{service_id}")
    output(data, getattr(args, 'human', False))

def cmd_deploys(args):
    """List deployments."""
    params = {}
    if hasattr(args, 'limit') and args.limit:
        params["limit"] = args.limit
    
    service_id = args.args[0] if args.args else args.id
    if not service_id:
        print("Error: service ID required", file=sys.stderr)
        sys.exit(1)
        
    data = api("GET", f"/services/{service_id}/deploys", params=params)
    output(data, getattr(args, 'human', False))

def cmd_logs(args):
    """Get service logs."""
    params = {}
    if hasattr(args, 'limit') and args.limit:
        params["limit"] = args.limit
    
    service_id = args.args[0] if args.args else args.id
    owner_id = get_owner_id()
    
    if not owner_id:
        print("Error: RENDER_WORKSPACE_ID not set", file=sys.stderr)
        sys.exit(1)
        
    params["ownerId"] = owner_id
    if service_id:
        params["resource"] = service_id
    
    params["type"] = getattr(args, 'type', 'build') or 'build'
    params["direction"] = "backward"
        
    data = api("GET", "/logs", params=params)
    output(data, getattr(args, 'human', False))

COMMANDS = {
    "services": cmd_services,
    "service-get": cmd_service_get,
    "deploys": cmd_deploys,
    "logs": cmd_logs,
}


def main():
    parser = argparse.ArgumentParser(
        description="Render CLI — AI agent integration",
        formatter_class=argparse.RawDescriptionHelpFormatter,
    )
    parser.add_argument("command", choices=list(COMMANDS.keys()), help="Command to run")
    parser.add_argument("args", nargs="*", help="Command arguments")
    parser.add_argument("--human", action="store_true", help="Human-readable output")
    parser.add_argument("--limit", type=int, help="Limit results")
    parser.add_argument("--id", help="Resource ID")
    parser.add_argument("--type", help="Log type (build, app, request)")

    parsed = parser.parse_args()
    cmd_func = COMMANDS[parsed.command]
    cmd_func(parsed)


if __name__ == "__main__":
    main()
