@echo off
setlocal

echo Validating sources.
set "_apiPath=.\api"
if not exist "%_apiPath%\Dockerfile" (
  echo Can't find Dockerfile for encoder api
  goto end
)

set "_webPath=.\web-views"
if not exist "%_webPath%\Dockerfile" (
  echo Can't find Dockerfile for encoder web app
  goto end
)

set "_authPath=.\auth"
if not exist "%_authPath%\Dockerfile" (
  echo Can't find Dockerfile for encoder auth
  goto end
)

echo start api
cd %_apiPath%
docker build . -t oneinc-test-api
docker run -d -p 5285:80 --name api oneinc-test-api

cd..
echo start web views
cd %_webPath%
docker build . -t oneinc-test-web
docker run -d -p 44446:80 --name web oneinc-test-web

cd..
echo start auth
cd %_authPath%
docker-compose build
docker run -d -p 44445:80 --link web:web --name auth oneinc-test-auth

:end
set /p Exit=Press Enter to close...