#!/bin/bash
# My first script

echo "Build started.."

docker-compose -f docker-compose.yml -f docker-compose.override.yml up --build

echo "Build completed!!!"