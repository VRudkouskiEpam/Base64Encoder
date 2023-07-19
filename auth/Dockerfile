FROM nginx:alpine

ENV HTPASSWD='usr:$2y$05$5AQr.0.p2oO3vL6owgsYdOJOawnLZC5/eMctrPDD56gUQl6hcFMl2' \
    FORWARD_PORT=80 \
    FORWARD_HOST=web
	
WORKDIR /opt

RUN apk add --no-cache gettext

COPY auth.conf auth.htpasswd launch.sh ./

CMD ["./launch.sh"]
