ARG ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
ARG ASPNETCORE_ENVIRONMENT
ENV ASPNETCORE_ENVIRONMENT=$ASPNETCORE_ENVIRONMENT
RUN echo ${ASPNETCORE_ENVIRONMENT}
WORKDIR /App

COPY . ./
RUN echo "Set work dir"
WORKDIR /App/src/Server/XmasTreeServiceWebApi

RUN echo "Build project"
RUN dotnet restore
RUN dotnet publish  --runtime linux-arm64 --self-contained -o out

FROM mcr.microsoft.com/dotnet/runtime:8.0
RUN apt-get update && \
    #apt-get install -y python3 python3-pip python3-lgpio python3-pigpio python3-gpio python3-gpiozero wget   && \
    apt-get install -y python3 python3-pip wget   && \
    rm -rf /var/lib/apt/lists/*

RUN pip install --break-system-packages lgpio pigpio gpio gpiozero numpy

RUN wget https://github.com/Gadgetoid/PY_LGPIO/releases/download/0.2.2.0/lgpio-0.2.2.0.tar.gz
RUN pip install --break-system-packages lgpio-0.2.2.0.tar.gz

ARG ASPNETCORE_ENVIRONMENT
ENV ASPNETCORE_ENVIRONMENT=$ASPNETCORE_ENVIRONMENT
RUN echo ${ASPNETCORE_ENVIRONMENT}
WORKDIR /App/XmasTreeServiceWebApi

RUN echo "Copy binaries from build-env"
COPY --from=build-env /App/src/Server/XmasTreeServiceWebApi/out .
ENTRYPOINT ["dotnet", "XmasTreeServiceWebApi.dll", "--urls=http://0.0.0.0:5000/"]
#CMD [./XmasTreeServiceWebApi]