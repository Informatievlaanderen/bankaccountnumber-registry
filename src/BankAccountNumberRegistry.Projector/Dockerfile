FROM microsoft/dotnet:2.2.0-runtime-deps

LABEL maintainer "agentschap Informatie Vlaanderen <informatie.vlaanderen@vlaanderen.be>"

COPY / /app
WORKDIR /app

EXPOSE 5000/tcp
ENV ASPNETCORE_URLS http://*:5000

ENTRYPOINT ["./BankAccountNumberRegistry.Api.Projector"]
