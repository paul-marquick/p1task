# p1task
P1 Investment Management task.

Projects in the solution:

- SecclConnector - (ClassLib) http client to make requests to the SECCL API.
- SecclConnector.Test - (XUnit) test the seccl connector functions.
- Aggregator - (ClassLib) busniess logic that calculates the aggregates.	
- Aggregator.Test - (XUnit) test the aggregator functions. (haven't done this)	
- Models - (ClassLib) record classes for the Balances and valuations data. Shared with api and web app.
- WebApi - (WebApi) listens for requests and responds with appropriate output using minimal code.
- WebApp - (Blazor WASM) UI to display the seccl totals  data to the user.

Things complete / not up to standard.

- Haven't written tests for the Aggregator project.
- The blazor app has the httpclient code in the home page code block. This should be in a class.
- The blazor app should be using appsettings in wwwroot to store the api url.
- The blazor app should have a loading spinner when waiting for the api response.
- The endpoint in the web api should not have code in it, the code should be moved to class(es) and called from the MapGet endpoint.
- If want to run the seccl connector tests needs to add secrets to the fields in HttpClientTestBase.
- Haven't added a test call to the web api http file.

To run the solution need add user secrets to the WebApi project. 
Also need to set up VS to start multiple projects.
Details will be in email message. 