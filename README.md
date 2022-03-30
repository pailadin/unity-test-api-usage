# Introduction

This was an attempt to see if Unity3D's ability to export WebGL would be useful in making front-ends.

Games can perform well in a browser afterall, so a more simple webapp might be an idea worth looking into.

We're also required in my current company to do something experimental like this quarterly, and I wanted to learn Unity3D for the third time (never seems to stick).

# The Journey

I fairly quickly found [a tutorial on how you can communicate with an API in Unity](https://gamedevacademy.org/how-to-connect-to-an-api-with-unity/).

I did deviate pretty quickly as I wanted:
1. My app to be responsive to the screen resolution, though I don't think I succeeded.
2. I wanted to use a different API
3. I did not need certain features like "fireworks".

Two big problems appeared early on and consumed the bulk of the time on this project:
1. I want to display the results I'm fetching, but they did not display correctly.
2. The URL I typed in had extra characters appended to it.

For the former, unfortunately I neglected to save the links that helped me, but searching for how to use "layout groups" will help.

For the latter, I found [this thread](https://gamedevacademy.org/how-to-connect-to-an-api-with-unity/) with a workaround.

# Final Thoughts

Maybe it is faster, I didn't even try to profile anything, and maybe if one is an experienced Unity dev this might be worth it...

However, for people already making websites the old fashioned way, I do not think it's worth switching to this method. The textbox string behavior on its own was too much hassle.
