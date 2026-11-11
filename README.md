# Plant360

Sample .NET 8 solution for the **GitHub for .NET Developers** session.

| Project | Purpose |
|---|---|
| `src/Plant360.Core` | Domain code: devices and billing |
| `src/Plant360.Api` | ASP.NET Core minimal API that exposes the core code |
| `tests/Plant360.Tests` | xUnit tests run by GitHub Actions |

## Run locally

```bash
dotnet restore Plant360.sln
dotnet build Plant360.sln
dotnet test Plant360.sln
dotnet run --project src/Plant360.Api      # http://localhost:5080/devices
```

Use `src/Plant360.Api/Plant360.Api.http` (VS / VS Code REST Client) to send sample requests.

## Team workflow

1. `git switch master && git pull origin master`
2. `git switch -c feature/<task-name>`
3. Commit, then `git push -u origin feature/<task-name>`
4. Open a Pull Request into `master`. CI (`.NET CI`) must pass and one reviewer must approve.
5. Merge. Never push directly to `master` (it is protected).

Branch names: `feature/device-validation`, `bugfix/login-error`, `hotfix/critical-alert`.
