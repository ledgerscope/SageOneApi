# About

Normally we would have integrated tests, with the tests alongside the classes they are testing.  But for our Ledgerscope development use, we like to use a debug version of the code in our Nuget, so that we can include full PDB class listings and be able to step into them.  That introduces dependencies on test SDK and test adapter, which would then be there even in the release version of our code that makes use of the nuget.  

So in this case (only) - the case of a nuget we deploy for ourselves - we move the tests off into a test project.