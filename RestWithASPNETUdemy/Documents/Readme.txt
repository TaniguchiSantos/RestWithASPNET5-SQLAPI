Sugestões para HATEOAS 
(Evitando NullReferenceException 
e Compatibilizando com versionamento, principalmente .NET5)
1) A execução das Tasks estavam retornando null 
nos métodos EnrichModel das Classes BookEnricher e PersonEnricher, 
assim lançando uma exceção NullReferenceException. 
Para sinalizar a finalização da tarefa e 
retornar um objeto mais apropriado, 
realizei a substituição:

de:

return null;

para:

return Task.CompletedTask;

2) Eu também notei que a partir da versão 5.0.0 da Microsoft.AspNetCore.Mvc.Versioning 
o método IUrlHelper.Link passou a adicionar como um parâmetro a versão da API no fim da 
URL por não tê-lo identificado na rota DefaultApi. Ex:

https://localhost:44300/api/person/v1/1?version=1

Com a intenção de compatibilizar essa implementação de HATEOAS 
com o versionamento da API eu realizei dois ajustes:

Nas atribuições das variáveis path das implementações dos Enricher 
(BookEnricher e PersonEnricher) eu removi a identificação de versão 
que estava fixa. Exemplo da PersonEnricher:

de:

var path = "api/person/v1";

para:

var path = "api/person";


E na criação dos Endpoints da Startup 
eu fiz apliquei a identificação da versão:

de:

endpoints.MapControllerRoute("DefaultApi", "{controller=values}/{id?}");

para:

endpoints.MapControllerRoute("DefaultApi", "{controller=values}/v{version=apiVersion}/{id?}");