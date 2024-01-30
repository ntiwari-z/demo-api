# api-test-suite

## Name
API Test Suite

## Description
Welcome to the Api Test Suite repository! This repository contains a comprehensive suite of tests using the xUnit testing framework, integrated with Allure for enhanced reporting capabilities. These tests cover various aspects of our application, helping us identify and address potential issues early in the development process.

## Prerequisites
- [ ] [Docker](https://docs.docker.com/get-docker/)

## Allure Reporting
To browse the results using Allure, simply run the ```docker-compose up``` command.
Click [here](http://localhost:5050/allure-docker-service/projects/default/reports/latest/index.html) to view report.
```
cd Tests
dotnet build
dotnet test
docker-compose up
```

## Examples
```
dotnet test #runs all test cases
dotnet test --filter TestCategory=Smoke #Runs the Test Suite marked as Smoke
dotnet test --filter TestCategory=Regression #Runs the Test Suite marked as Regression
```
