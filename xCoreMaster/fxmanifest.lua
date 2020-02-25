fx_version 'adamant'
games { 'gta5' }

client_scripts {
	"xCore.net.dll",
}

server_script {	
    "xCoreServer.net.dll",
} 


dependencies { 'mysql-async' }

ui_page "html/index.html"

files {
	"Newtonsoft.Json.dll",
	
	"html/index.html",
	
	"html/scripts/config.js",
	"html/scripts/listener.js",
	"html/scripts/SoundPlayer.js",
	
	"html/sound/gta.mp3",
	"html/sound/radio.mp3",
	"html/sound/claps.mp3",
	"html/sound/naruto.mp3",
}