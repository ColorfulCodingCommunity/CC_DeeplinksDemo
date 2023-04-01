# Deeplinks Demo project for Android/iOS

## Support Project for YT Video:
https://www.youtube.com/watch?v=bKiwNfNqKAc

# Instructions 

## Apple setup
Put `apple-app-site-association` on the same hosting as your website. Make sure the URL schema is the one you use for your web domain.


## Web setup

Make a web page with one button that open's the needed URL.

It will try open the app using the Deeplink, otherwise it will open the app store.
On Google we have to open the store manually. iOS should automaticall open App Store.

JS Code for the button:

```
tryOpen = ()=> {
    var userAgent = navigator.userAgent || navigator.vendor || window.opera;
    if (userAgent.match(/iPhone|iPad|iPod/i)) {
        window.location = "https://artlink.app/app.html" + deepLinkQuery;
    } else {
        window.location = "artlink://artlink.app" + deepLinkQuery;
        setTimeout(function () {
            window.location = "https://play.google.com/store/apps/details?id=com.colorfulcoding.artlink";
        }, 3000);
    }
};
```