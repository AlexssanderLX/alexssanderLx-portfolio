# Deployment

This portfolio uses GitHub Actions for validation and a manual production deployment.

## Safe flow

1. Push a feature or integration branch.
2. Open a pull request into `main`.
3. Wait for the CI workflow to pass.
4. Merge the pull request into `main`.
5. Open GitHub Actions.
6. Select `Deploy production`.
7. Click `Run workflow`.
8. Select branch `main`.
9. Type `deploy production` in the confirmation field.
10. Start the workflow.

## Rules

- Production deploys must run from `main`.
- The deploy workflow does not run automatically on push.
- Do not deploy directly from feature branches.
- Do not store VPS credentials in the repository.
- Configure production values only as GitHub Secrets.

## Required GitHub Secrets

- `VPS_HOST`
- `VPS_USER`
- `VPS_SSH_PRIVATE_KEY`
- `APP_REMOTE_DIR`
- `APP_SERVICE_NAME`

Optional:

- `VPS_PORT`
- `APP_HEALTHCHECK_URL`

## Current production target

The default remote directory is `/var/www/portfolio/publish` when `APP_REMOTE_DIR` is not set.
The default systemd service is `portfolio` when `APP_SERVICE_NAME` is not set.
