# brustkrauler
Very simple config-file-based webcrawler. Born to tell me when something has changed.
Made to follow the currently available learn courses at our public swimming pool.

## Getting started

In this state there are three things to do:

### 1. Compile

Compile the tool via `dotnet build -c Release`

### 2. Add a config file

Add a config file named `crawler.json` in the same folder with the tools `dll`.
There is a  [sample file](https://github.com/renao/brustkrauler/blob/main/Brustkrauler/crawler.json.template) available in the repository.

### 3. Run it.

Run the tool via `dotnet brustkrauler.dll`
