# DNFS - Salt Stars Day 4

## A. Scenario

It's a very different CTO that tip-toes into the room and slides up to your desk in his patented Fred Astaire slide-step glide.

> Well, well, well ... that went down well. The little rascal son of our CEO noticed that you used the API and since it worked we got praise for a job well done.

Have he ever smiled this much?

> But as I tried to explain that only used the Web API and that nothing could be `seen` we now got another bag of money to make it visible on our web page.

After you high-fived him, you gently ask why the big smile?

> Well, the bag of money is much bigger than we need. So if you put the data on the site today, we can all go out for beers, food and a show afterwards. I love clueless business people!

He makes a drumroll on your desk, start singing "Start spreading the news... I'm leeeeeaaaaaaving today" while dancing out into the corridor again.

## B. What you will be working on today

Today is all about the front-end and you will consume a version of the WebAPI (in `Salt.Stars.API`) that we have created.

You will get your hands dirty in Razor and making the two web pages; one for listing all heroes as well as navigating to one individual hero page.

## C. Tools and requirements

- Use Visual Studio Code - not Visual Studio Community Edition
- Let the tests guide you in your design
- Notice that today we have End-to-end tests that needs to be working (`Salt.Stars.E2E`)

## D. Lab instructions

The exercise today is a bit more bare-bones than before, and not much skeleton code is written. However, you have the Index page and the Greeting API-client class to help you with some example code. It uses a very similar flow as the one that you need to build in order to make this work.

Here is what you need to do:

- Create a API-client class that calls the `Salt.Stars.API` to get all heroes and one hero.

  - You can inspect the code or use swagger on <https://localhost:5001/swagger/index.html> to try the API out
  - You will need to have the API running to access it
  - Make sure that the API-client class has an Interface
  - Register the Interface in the dependency resolver (just as `IGreeting`)

- Build a `Heroes` Razor page (and Page model class) that lists all heroes

  - Make the constructor of page take a parameter of the client Interface
  - Get the heros list in the `OnGetAsync` method, using the API-client
  - Make the page look nice
  - Ensure to have a link to the `Hero` page
    - use the `asp-page` and `asp-route-id` tag helpers
  - Show the following data:
    - Name
    - Height
    - Weight

- Build a `Hero` Razor web page that shows details about one here
  - Use the same structure as for the `Heroes` pages when it comes to getting the data from the API-client
  - Make the page look nice
  - Show the following data:
    - Name
    - Height
    - Weight
    - Birth year
    - Requested At

You are finished when the End2End tests pass and the web site looks nice.

Hurry up - the CTO has promised beers and a show! :)

### Tips

- Be sure to go slow and take break.
- There will be a lot of failing tests - they are there to help you know what and how to code
- Read up on [Razor pages](https://docs.microsoft.com/en-us/aspnet/core/razor-pages/?view=aspnetcore-2.0&tabs=visual-studio-code)
- There's a `dotnet` command to generate a new Razor page that you'll find useful:

  ```bash
  dotnet new page --name People --namespace Marcusoft.Web.Pages --output Pages
  ```

---

Good luck and have fun!
