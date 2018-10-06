# DBServerTest
This is a project developed to a job application at DBServer. Basically, it consists in a website where you can vote for the restaurant that you and your team are going to.

The project was developed using Microsoft Visual Studio Community 2015, .NET Framework 4.5.2 and IIS 6.2.
For dependency injection it was used Unity framework. For the unit tests mocks it was userd NSubstitute. The webapi was built using the .NET default libraries.

To open the website, access: http://localhost/DBServerTest/ 

The home is the poll page. You choose your favorite restaurant and vote. After, you see the current results. Also, you can not vote again during 2 minutes (simulating the idea that you can not vote twice a day).

The data is fake, since the database it was not built (it was not a require for this job application).
