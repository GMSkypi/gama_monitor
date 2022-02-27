FROM maven:3.8.4-openjdk-17-slim AS builder  
COPY . /app  
WORKDIR /app 
RUN mvn clean package 
WORKDIR /app/target
#CMD exec /bin/bash -c "trap : TERM INT; sleep 10000000000000 & wait"
RUN java -Djarmode=layertools -jar data_monitor-1.0-SNAPSHOT.jar extract

FROM openjdk:17-jdk-alpine
WORKDIR /app/build
#RUN apk update && apk add bash
#COPY --from=builder /app/target /app/build
#COPY ./notifications.json /app/build/notifications.json
#COPY ./configuration.properties /app/build/configuration.properties

COPY --from=builder /app/target/dependencies/ /app/build/
COPY --from=builder /app/target/snapshot-dependencies/ /app/build/
COPY --from=builder /app/target/spring-boot-loader/ /app/build/
COPY --from=builder /app/target/application/ /app/build/
ENTRYPOINT ["java", "org.springframework.boot.loader.JarLauncher"]

#CMD exec /bin/bash -c "trap : TERM INT; sleep 10000000000000 & wait"
#ENTRYPOINT ["java", "-jar", "data_monitor-1.0-SNAPSHOT.jar"]

#FROM adoptopenjdk:11-jre-hotspot as builder
#WORKDIR app
#ARG JAR_FILE=target/*.jar
#COPY ${JAR_FILE} application.jar
#RUN java -Djarmode=layertools -jar application.jar extract

#FROM adoptopenjdk:11-jre-hotspot
#WORKDIR application
#COPY --from=builder app/dependencies/ ./
#COPY --from=builder app/snapshot-dependencies/ ./
#COPY --from=builder app/resources/ ./
#COPY --from=builder app/application/ ./
#ENTRYPOINT ["java", "org.springframework.boot.loader.JarLauncher"]




