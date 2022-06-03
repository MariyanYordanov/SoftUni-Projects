# Build a simple mobile app using only HTML, CSS, and JavaScript

Setting up Workbox https://developer.chrome.com/docs/workbox/modules/workbox-cli/

Google workbox is the tool that will generate service workers, which will make our app work without an internet connection. First, let’s install workbox globally on our machine. Run:

	npm install workbox-cli --global
  
Then to configure our workbox, run:

	npx workbox-cli wizard
  
