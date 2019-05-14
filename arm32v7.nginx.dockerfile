FROM arm32v7/alpine

RUN mkdir -p /run/nginx
RUN mkdir -p /run/sshd
# enable ssh
RUN apk --update add --no-cache openssh bash nano nginx\
  && mkdir -p /home/root/.ssh /etc/authorized_keys && chmod 700 /home/root/.ssh/ \
  && rm -rf /var/cache/apk/*
RUN sed -ir 's/#PermitRootLogin.*/PermitRootLogin yes/g' /etc/ssh/sshd_config
RUN sed -ir 's/#PasswordAuthentication.*/PasswordAuthentication yes/g' /etc/ssh/sshd_config
RUN sed -ir 's/AuthorizedKeysFile/#AuthorizedKeysFile/g' /etc/ssh/sshd_config
RUN sed -ir 's/#ListenAddress 0\.0\.0\.0.*/ListenAddress 0.0.0.0/g' /etc/ssh/sshd_config
RUN sed -ir 's/#ListenAddress ::.*/ListenAddress ::/g' /etc/ssh/sshd_config
RUN sed -ir 's/#Port 22/Port 22/g' /etc/ssh/sshd_config
RUN sed -ir 's/#HostKey \/etc\/ssh\/ssh_host_key/HostKey \/etc\/ssh\/ssh_host_key/g' /etc/ssh/sshd_config
RUN sed -ir 's/#HostKey \/etc\/ssh\/ssh_host_rsa_key/HostKey \/etc\/ssh\/ssh_host_rsa_key/g' /etc/ssh/sshd_config
RUN sed -ir 's/#HostKey \/etc\/ssh\/ssh_host_dsa_key/HostKey \/etc\/ssh\/ssh_host_dsa_key/g' /etc/ssh/sshd_config
RUN sed -ir 's/#HostKey \/etc\/ssh\/ssh_host_ecdsa_key/HostKey \/etc\/ssh\/ssh_host_ecdsa_key/g' /etc/ssh/sshd_config
RUN sed -ir 's/#HostKey \/etc\/ssh\/ssh_host_ed25519_key/HostKey \/etc\/ssh\/ssh_host_ed25519_key/g' /etc/ssh/sshd_config
RUN /usr/bin/ssh-keygen -A
# RUN ssh-keygen -t rsa -b 4096 -f  /etc/ssh/ssh_host_key
ADD ssh/ssh_host_key      /etc/ssh/ssh_host_key
ADD ssh/ssh_host_key.pub  /etc/ssh/ssh_host_key.pub
RUN echo 'root:root' | chpasswd

# update bash
RUN sed -i 's/root:x:0:0:root:\/root:\/bin\/ash/root:x:0:0:root:\/root:\/bin\/bash/' /etc/passwd

RUN adduser -D -g 'www' www && \
    mkdir /www && \
    chown -R www:www /var/lib/nginx && \
    chown -R www:www /www
ADD html/index.html /www

STOPSIGNAL SIGTERM

EXPOSE 22 80 443

ADD nginx.sh /
ENTRYPOINT ["sh", "nginx.sh"]
