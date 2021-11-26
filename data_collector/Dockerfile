FROM alpine:latest AS builder

#RUN apk add --no-cache curl
RUN apk add --no-cache curl-dev
RUN apk add --update --no-cache \
build-base \
cmake
RUN apk add --no-cache bash

#ENTRYPOINT ["/usr/bin/curl"]

WORKDIR /src/app
COPY . .
RUN cmake -B ./build/ .
WORKDIR /src/app/build
RUN make
CMD ["/src/app/build/data_collector"]
#CMD ["./data_collector"]
#WORKDIR /src/app
#CMD ["/src/app/infSleep"]
#WORKDIR /src/app/compiled/
#CMD ["/src/app/compiled/data_collector"]

#FROM alpine:latest
#WORKDIR /app
#COPY --from=builder /src/app/ /app/
#CMD ["/app/build/data_collector"]
