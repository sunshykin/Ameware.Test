using System;
using System.Net.Http;
using Ameware.Test;

var client = new HttpClient() { BaseAddress = new Uri("https://api.jsonbin.io/b/5fb62f9404be4f05c9272f9b/2") };
client.DefaultRequestHeaders.Add("secret-key", "$2b$10$FRKBdPsyV27ReVeMpo83U.BYS0Jko5KUjctlj0A865qRkEYVf49ty");

var dataService = new DataService(client);
var items = await dataService.GetItemsAsync();
var nodes = items.ToTree();
var display = nodes.MakeFormattedString();

Console.WriteLine(display);