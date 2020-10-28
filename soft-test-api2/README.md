

# API 2

## 1) Calcular Juros

* Nome da rota "/calculajuros"
* Executar cálculo em memória da fórmula ` Valor Inicial * (1 + juros) ^ Tempo` onde:
  - ` Valor Inicial `: é um decimal recebido como parâmetro;
  - ` juros`: deve ser um valor retornado pela API ` Soft.InterestRate.Api `;
  - `Tempo`: deve ser um valor inteiro representando o número de meses;
  - `^` representa o símbolo de potência;
  - `*` representa o símbolo de multiplicação;
  - `+` representa o símbolo de soma
> **observação** O resultado final de ser truncado (não conter arredondamento) e deve conter duas casas decimais somente.

## 2) Show me the code
* Nome da roda "/showmethecode"
* Path no Git com o código fonte

## Solution `CalculateInterest.sln`

A Solution é composta por três projetos

1- `Soft.CalculateInterest.Api`
- Representa a camada de aplicação, responsável unicamente por efetuar a comunicação entre a apresentação e a domínio.

2 - `Soft.CalculateInterest.Application`
- Optei por criar uma camada adicional de aplicação no intuito de facilitar a criação de testes unitários.

3 - `Soft.CalculateInterest.Domain`
- Representa a camada de domínio, responsável por fornecer o valor a ser utilizado.

## Consumindo o Domínio

Dependências

1 - `HttpClient` Provider responsável por fazer a comunicação com a API `Soft.InterestRate.Api`

2 - `JurosRateService` é uma implementação de `INavigator` que faz a integração com a API `Soft.InterestRate.Api`

3 - `CalculateInterestService` é uma implementação de `ICalculateInterestService` que faz o cálculo dos juros.

4 - `CalculateInterestApplication` é a camada de aplicação que realmente fará o cálculo.

5 - O URL da API `Soft.InterestRate.Api` pode ser setada no código de duas formas: a) fixo no arquivo appsettings.json e b) Através de uma **variavel de ambiente da máquina** `APIURL`

6 - Invertendo o controle. O controle da injeção de dependências foi dado ao .net core.

```csharp
	#region Dependences
            var urlApi = Environment.GetEnvironmentVariable("APIURL", EnvironmentVariableTarget.Machine);

            if (string.IsNullOrEmpty(urlApi))
            {
                Program.RateApi = this.Configuration.ReadConfig<string>("Program", "RateApi");
            }
            else
            {
                Program.RateApi = urlApi;
            }

            services.AddScoped<HttpClient>();
            services.AddScoped<INavigator, JurosRateService>();
            services.AddScoped<ICalculateInterestService, CalculateInterestService>();
            services.AddScoped<CalculateInterestApplication>();  
	#endregion
```

