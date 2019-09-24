# Dynamic CORS policy using .NET CORE middleware

Add allowed origins dynamically without restarting API.


Cross-origin resource sharing is a mechanism that allows restricted resources on a web page to be requested from another domain outside the domain from which the first resource was served. A web page may freely embed cross-origin images, stylesheets, scripts, iframes, and videos. Wikipedia

CORS support with ASP.NET provides a secured way to allow other to use your code in development. You can allow specific origins  in startup file or as an attribute on Controller also.  That means when a new origin  is added to your allowed origins list, the microservice/API needed to be recycle. 

To solve this issue , We can add a middle ware that add new policies to your existing CORS policy before every request. This middle can also use dependency injection and we can use constructor injection with it which is not possible while you create a custom attribute.
