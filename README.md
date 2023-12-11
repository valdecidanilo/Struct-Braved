# Estrutura Braved

## Visão Geral

Este guia oferece uma compreensão aprofundada da estrutura do código em C# no Unity, proporcionando clareza, fácil manutenção e extensibilidade para o seu projeto.

Projeto Demonstrativo: [Projeto Demo](https://github.com/valdecidanilo/Struct-Braved)

Pacotes recomendados:
- [Addressables](https://docs.unity3d.com/Manual/com.unity.addressables.html)
- [Universal RP](https://docs.unity3d.com/Packages/com.unity.render-pipelines.universal@17.0/manual/index.html)
- [NewtonSoft Json](https://github.com/applejag/Newtonsoft.Json-for-Unity/wiki/Install-official-via-UPM)

![UML da estrutura](https://github.com/valdecidanilo/Struct-Braved/blob/main/blob/struct.png?raw=true)
*(Imagem criada a partir do programa StarUML)*

## Sobre a Estrutura

### GameManager

O **GameManager** é um Monobehaviour que tem um papel crucial de ser o coração do projeto. Ele não apenas orquestra, mas também gerencia os controladores, interações ambientais e eventos. Este script oferece métodos e propriedades essenciais para controlar eventos, estados e views. É a engrenagem mestra que mantém todo o sistema coeso para a fluidez e eficácia do seu projeto. 
- O GameManager deve conter todas as referências dos controladores.

### Controllers

Os **controladores** são classes Monobehaviour que residem na hierarquia da cena. Eles instalam as Views e ouvem seus eventos. Essa interação permite a mudança da interface do usuário na própria view de referência ou a ativação de ações para scripts externos utilizarem. 
- Cada controlador deve conter uma referência do seu canvas para instanciar suas views.

### Views

As **views** representam a interface visual. Elas recebem todas as referências dos componentes e as ações correspondentes, como cliques de botão, mudanças de entrada de texto, e assim por diante. As Views desempenham um papel crucial na interação direta com o usuário. 
- As views terão a interface IView e vão instanciar o prefab com o script do componente.

### Componentes

Os **componentes** são Monobehaviour, são elementos fundamentais que as Views utilizam para adquirir todas as referências de UI necessárias. Essas referências incluem elementos como Image, TMP_Text, Button, entre outros. Os componentes são essenciais para a construção e manipulação eficiente da interface do usuário.

Essa estrutura proporciona uma organização clara e eficiente, garantindo a manutenção fácil e escalabilidade do projeto. O GameManager atua como o maestro, enquanto controladores, views e componentes colaboram harmoniosamente para criar uma experiência coesa e envolvente.

![Hierarquia da estruturação](https://github.com/valdecidanilo/Struct-Braved/blob/main/blob/hierarchy.png?raw=true)
*(Imagem demonstrativa da estrutura de pasta hierarquia da cena e as propriedades dos GameObject.)*

## Organização de Pastas

- **Assets**: Repositório de recursos utilizados no projeto, tais como modelos 3D, texturas e efeitos sonoros.
  
- **Scripts**: Contém todos os scripts C# essenciais para o projeto.
  
- **Prefabs/Resources**: Local onde são armazenados todos os assets de prefab padrão gerados pelo Unity.
  
- **Addressables**: Integração com o pacote Addressable para o eficiente carregamento/descarregamento de ativos e instâncias em memória.
  
- **Models**: As classes na pasta Models são dedicadas à tradução eficiente dos dados de Serviços e Web Requests. Simplificam informações complexas para que o código possa facilmente entender e utilizar.
  
- **State**: Opcional, envia eventos dos serviços para o GameManager, proporcionando uma estrutura organizada de gerenciamento de estados.
  
- **Utils**: As Classes na pasta Utils são dedicadas para suporte e funcionalidades extras, contribuindo para a robustez do projeto.
  
- **Services**: Serviços externos residem nesta pasta, encaminhando eventos para o State ou GameManager.

## Interfaces Principais

- **IController.cs**: Implementa métodos essenciais para uma operação padrão.

- **IView.cs**: Toda view deve aderir à interface IView, estabelecendo um padrão de estrutura e facilitando a manutenção.

## Considerações Finais

Este guia proporciona uma visão detalhada da estrutura do código em C# no Unity. Manter a documentação atualizada é fundamental à medida que o projeto evolui, adicionando informações sobre novas classes, métodos e propriedades. Isso assegura que a equipe compreenda o código de maneira clara e eficiente, promovendo uma colaboração suave e eficaz.
