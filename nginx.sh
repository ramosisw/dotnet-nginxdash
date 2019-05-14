#!/bin/bash
echo "Starting sshd..."
/usr/sbin/sshd -e -f /etc/ssh/sshd_config
echo "Starting nginx..."
/usr/sbin/nginx -g "daemon off;"
#rc-service nginx start
#echo "Ready!"