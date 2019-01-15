FROM envoyproxy/envoy:latest
WORKDIR /app
COPY ["envoy.yaml", "envoy_win.yaml"]
RUN tr -d '\15\32' < envoy_win.yaml > envoy.yaml
COPY envoy.yaml /etc/envoy/envoy.yaml
