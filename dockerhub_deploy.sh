#!/bin/bash
echo "$DOCKER_PASSWORD" | docker login -u "$DOCKER_USERNAME" --password-stdin
docker push vijayshinva/chirper:latest
docker push vijayshinva/chirper-identity:latest
docker push vijayshinva/chirper-webapi-messages:latest
docker push vijayshinva/chirper-webapi-wall:latest
docker push vijayshinva/chirper-web:latest
docker push vijayshinva/chirper-front-envoy:latest