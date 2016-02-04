# Stupid Web Server
This is a tiny little web server meant for serviing static files over http. 
Files could be html, css, images, json, css, script, or any other documents.


## Examples:

to server a single file 

```
StupidWebServer servefile --file beautiful.html --url http://localhost:4300

StupidWebServer servefile --file sample.json --url http://localhost:3000/getdata
```

To serve a folder over http

```
StupidWebServer servefolder --directory c:\mystaticwebsite --url http://localhost:2500
```
