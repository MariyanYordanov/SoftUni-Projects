# Build a simple mobile app using only HTML, CSS, and JavaScript

Setting up Workbox https://developer.chrome.com/docs/workbox/modules/workbox-cli/

Google workbox is the tool that will generate service workers, which will make our app work without an internet connection. First, let’s install workbox globally on our machine. Run:

	npm install workbox-cli --global
  
Then to configure our workbox, run:

	npx workbox-cli wizard
  
In the console, you will be asked to register the root path of your application. build/ is standart enter path, then use 

	build/ 
	
as the root path.Then, select cache all files - .html, .css, .js
