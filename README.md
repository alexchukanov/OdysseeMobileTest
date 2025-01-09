API & Integration Developer – Test

Context:
We have a list of Object get from other ERP system and it need to import to Odyssee using Odyssee API. Object list available in Excel or CVS format.


Goal of the test: 
Develop a small tool that read the Excel or CVS file and import data to Odyssee. Here are the key point that should be achieved.

    1. Logic should be able to send only required objects(if the object already sent to Odyssee then update it, only if data is change in the document)
    2. Get the mandatory field using Odyssee API (Eg:  sales_territory_id etc.)
    3. Used the company.code in Odyssee to store the primary key of the ERP(code).
    4. To check company available on Odyssee, use Odata filter by company.code.
    5. Create additional function to get all company using paging.
    6. Coding in a generic way is always the best way (avoid copy paste, using power of .net)

    7. App should be powerful enough to be run each 1 sec (in a loop). Take care of resources and optimization. 
    8. Create a SLN in VisualStudio composed of 2 projects: a class library that do everything and an .exe that call the class library.


Odyssee API Company
Check https://developers.odysseemobile.com to find information about Odyssee API. You can use the following credentials to connect to Odyssee API: 
    • Domain =  SAMPLEAPI
    • username= test@sampleapi.com
    • password = 8f0690jjlkjIHZLKjZJlkZ
