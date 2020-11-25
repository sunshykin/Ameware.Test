# [EN] Ameware.Test

Test Task for Ameware Group.

## Description

Original description contains only the code below, so it shoould sound something like 'Make the code work properly':

```csharp
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

var client = new HttpClient() { BaseAddress = new Uri("https://api.jsonbin.io/b/5fb62f9404be4f05c9272f9b/2") };
client.DefaultRequestHeaders.Add("secret-key", "$2b$10$FRKBdPsyV27ReVeMpo83U.BYS0Jko5KUjctlj0A865qRkEYVf49ty");

var dataService = new DataService(client);
var items = await dataService.GetItemsAsync();
var nodes = items.ToTree();
var display = nodes.MakeFormattedString();

Console.WriteLine(display);

public static class NeedToImplementThis
{
	// TODO: Need to implement convert flat id-parent list to tree
	public static Node ToTree(this IEnumerable<Item> items) 
		=> throw new NotImplementedException();
	
	// TODO: Make string with nmarkup hierarchy of nodes
	public static string MakeFormattedString(this Node node) 
		=> throw new NotImplementedException();
	
	// output requirements:
	// <ul>
	// 		<li>{id}. {text} ({level})</li>
	// 		<ul>
	//			<li>{id}. {text} ({level})</li>
	//			....
	//			<li>{id}. {text} ({level})</li>
	// 		</ul>
	// </ul>
}

public class Node 
{
	public int Id { get; set; }
	public string Text { get; set; }
	public List<Node> Childs { get; set; }
	
	public bool IsRoot => Id == 0;
	public bool HasChilds => Childs != null && Childs.Any();
}

public class DataService 
{
	private readonly HttpClient _httpClient;
	public DataService(HttpClient httpClient) => _httpClient = httpClient;
	
	public async Task<IEnumerable<Item>> GetItemsAsync() {
		using var resp = await _httpClient.GetAsync("");
		var json = await resp.Content.ReadAsStringAsync();

		Console.WriteLine(json);
		return JsonConvert.DeserializeObject<Item[]>(json);
	}
}

public record Item 
{
	public int Id { get; }
	public string Text { get; }
	public int Parent { get; }
}
```


# [RU] Ameware.Test

Тестовое задание для Ameware Group.

## Описание

Оригинальное описание содержало только следующий код, так что сама задача должна звучать как 'Доработать код, чтобы он исполнялся корретно':

```csharp
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

var client = new HttpClient() { BaseAddress = new Uri("https://api.jsonbin.io/b/5fb62f9404be4f05c9272f9b/2") };
client.DefaultRequestHeaders.Add("secret-key", "$2b$10$FRKBdPsyV27ReVeMpo83U.BYS0Jko5KUjctlj0A865qRkEYVf49ty");

var dataService = new DataService(client);
var items = await dataService.GetItemsAsync();
var nodes = items.ToTree();
var display = nodes.MakeFormattedString();

Console.WriteLine(display);

public static class NeedToImplementThis
{
	// TODO: Need to implement convert flat id-parent list to tree
	public static Node ToTree(this IEnumerable<Item> items) 
		=> throw new NotImplementedException();
	
	// TODO: Make string with nmarkup hierarchy of nodes
	public static string MakeFormattedString(this Node node) 
		=> throw new NotImplementedException();
	
	// output requirements:
	// <ul>
	// 		<li>{id}. {text} ({level})</li>
	// 		<ul>
	//			<li>{id}. {text} ({level})</li>
	//			....
	//			<li>{id}. {text} ({level})</li>
	// 		</ul>
	// </ul>
}

public class Node 
{
	public int Id { get; set; }
	public string Text { get; set; }
	public List<Node> Childs { get; set; }
	
	public bool IsRoot => Id == 0;
	public bool HasChilds => Childs != null && Childs.Any();
}

public class DataService 
{
	private readonly HttpClient _httpClient;
	public DataService(HttpClient httpClient) => _httpClient = httpClient;
	
	public async Task<IEnumerable<Item>> GetItemsAsync() {
		using var resp = await _httpClient.GetAsync("");
		var json = await resp.Content.ReadAsStringAsync();

		Console.WriteLine(json);
		return JsonConvert.DeserializeObject<Item[]>(json);
	}
}

public record Item 
{
	public int Id { get; }
	public string Text { get; }
	public int Parent { get; }
}
```
