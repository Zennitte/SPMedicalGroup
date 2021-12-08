# SPMedicalGroup
<img src = "https://images.unsplash.com/photo-1576671081837-49000212a370?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1098&q=80" style = "width = 100%;">
<h2>Sobre</h2>
<p>Projeto proposto com o intuito de avaliar o conhecimento nos contéudos de Modelagem, Banco De Dados relacional e não relacional, uso da arquitetura Api, criação de páginas web com ReactJs e criação de aplicativos mobile com React Native.</p>
<h2>Escopo</h2>
<p>Uma nova clínica médica chamada SP Medical Group, empresa de pequeno porte que atua no ramo da saúde, foi criada pelo médico Fernando Strada em 2020 na região da Paulista em São Paulo. Fernando tem uma equipe de médicos que atuam em diversas áreas (pediatria, odontologia, gastrenterologia etc.). Sua empresa, por ser nova, iniciou a administração dos registros de forma simples, utilizando softwares de planilhas eletrônicas e, com o sucesso da clínica, sua gestão passou a se tornar complicada devido à alta demanda dos pacientes.</p>
<h2>Tecnologias</h2>
<div>
  <h3>Modelagem</h3>
  <img align = "center" alt = "Draw.io" height = "40" width = "40" src = "https://avatars.githubusercontent.com/u/1769238?s=200&v=4">
  <h3>Banco De Dados</h3>
  <img align = "center" alt = "SQL Server" height = "40" width = "40" src ="https://img.icons8.com/color/48/000000/microsoft-sql-server.png">
  <h3>Layout</h3>
  <img align = "center" alt = "Figma" height = "40" width = "40" src = "https://github.com/devicons/devicon/blob/master/icons/figma/figma-original.svg">
  <h3>Versionamento</h3>
  <img align = "center" alt = "Git" height = "40" width = "40" src = "https://github.com/devicons/devicon/blob/master/icons/git/git-original.svg">
  <h3>Back-End</h3>
  <img align = "center" alt = "C#" height = "40" width = "40" src = "https://github.com/devicons/devicon/blob/master/icons/csharp/csharp-original.svg">
  <h3>Front-End</h3>
  <img align = "center" alt = "Html" height = "40" width = "40" src = "https://github.com/devicons/devicon/blob/master/icons/html5/html5-original.svg">
  <img align = "center" alt = "CSS" height = "40" width = "40" src = "https://github.com/devicons/devicon/blob/master/icons/css3/css3-original.svg">
  <img align = "center" alt = "JavaScript" height = "40" width = "40" src = "https://github.com/devicons/devicon/blob/master/icons/javascript/javascript-original.svg">
  <img align = "center" alt = "ReactJs" height = "40" width = "40" src = "https://github.com/devicons/devicon/blob/master/icons/react/react-original.svg">
  <img align = "center" alt = "NodeJs" height = "40" width = "40" src = "https://github.com/devicons/devicon/blob/master/icons/nodejs/nodejs-original.svg">
</div>
<h2>Banco de Dados Relacional</h2>
<p>Banco de dados relacional é aquele que ordena os dados para que eles sejam vistos como tabelas ou relações. Ele é importante pois nos permite ordenar nossos dados de forma mais intendivel</p>
<h2>Modelagem</h2>
<p>Modelagem de dados é o método de criar um modelo do sistema para explicar suas características e comportamento para facilitar o entendimento do projeto, para evitar erros em seu desenvolvimento.</p>
<h3>Modelo Conceitual</h3>
<p>Esse modelo mostra as entidades de forma mais simples e estabelece as relações de cardinalidade.</p>
<img src ="https://github.com/Zennitte/SPMedicalGroup/blob/main/BD/Modelagem/conceitual/SPMedicalGroup-Conceitual-conceitual.png" style = "width = 100%">
<h3>Modelo Lógico</h3>
<p>Esse modelo mostra as entidades de forma mais complexa já contendo seus campos e também apresenta cardinalidade.</p>
<img src = "https://github.com/Zennitte/SPMedicalGroup/blob/main/BD/Modelagem/l%C3%B3gico/SPMedicalGroup-l%C3%B3gico-l%C3%B3gico.png" style = "width = 100%">
<h3>Modelo Físico</h3>
<p>Esse modelo representa de forma visual o banco de dados contendo as entidades, os campos e os dados armazenados nesses campos.</p>
<img src = "https://github.com/Zennitte/SPMedicalGroup/blob/main/IMG/ModeloFisica.png" style = "width = 100%">
<h2>Back-End</h2>
<p>Para este projeto optamos por desenvolver a nossa aplicação no formato de uma API, ela foi desenvolvida utilizando o Microsoft Visual Studio.</p>
<p><strong>Api</strong> é um conjunto de padrões e instruções estabelecidos para utilização do software, definindo as requisições e as respostas seguindo o protocolo HTTP, neste caso expresso no formato JSON, para que seja possível acessar o sistema em diversos dispositivos distintos sem a preocupação com a linguagem que será utilizada por estes.</p>
<p>Além disso, foi utilizado o estilo de arquitetura REST.</p>
<p><strong>API -</strong> Application Programming Interface – Interface de Programação de Aplicativos.</p>
<p><strong>HTTP -</strong> Hypertext Transfer Protocol – Protocolo de Transferência de Hipertexto.</p>
<p><strong>JSON -</strong> JavaScript Object Notation – Notação de Objetos JavaScript.</p>
<p><strong>REST -</strong> Representational State Transfer – Interface de Programação de Aplicativos.</p>
<p><strong>Entity Framework</strong> é um conjunto de tecnologias no ADO.NET que dão suporte ao desenvolvimento de aplicativos de software orientado a dados. O Entity Framework permite que os desenvolvedores trabalhem com dados na forma de objetos e propriedades específicos de domínio, como clientes e endereços de clientes, sem ter que se preocupar com as tabelas e colunas de banco de dados subjacentes em que esses data são armazenados.</p>
<p><strong>Swagger</strong> é uma ferramenta usada para documentar os endpoints da nossa API.</p>
<p><strong>DataBase First </strong>é o método de construção da API onde se usa as tabelas preexististentes no banco de dados, e os transforma em classes dentro da API</p>
<p><strong>JWT </strong>é o método de autenticação usado, onde a autenticação é por meio de tokens.</p>
<h2>Web</h2>
<p>A parte web do projeto resolvemos desenvolver em JavaScript mais especificamente usando a biblioteca ReactJs.</p>
<p>Foram desenvolvidas 4 páginas:</p>
<ul>
  <li>Login: Página que gera um token e redireciona para as outras páginas baseado no token gerado.</li>
  <li>Administrador: Página onde os administradores podem cadastrar e listar todas as consultas.</li>
  <li>Médico: Página onde os médicos podem listar suas próprias consultas e adicionar um prontuário as suas consultas.</li>
  <li>Paciente: Página onde os pacientes podem ver suas próprias consultas</li>
</ul>
<h2>Mobile</h2>
<p>A parte mobile do projeto foi desenvolvida em JavaScript, utilizando a biblioteca React Native que transpila o código em JavaScript para Java onde essa aplicação é emulada pelo Android Studio.</p>
<p>Foram desenvolvidas 4 telas:</p>
<ul>
  <li>Login: Tela onde é gerado o token e redireciona para outras telas caso o token seja válido.</li>
  <li>Consultas: Tela onde os médicos e os pacientes podem ver suas consultas.</li>
  <li>Logout: Tela onde os úsuarios podem deslogar do aplicativo, sendo redirecionados para login e tendo o token limpo</li>
  <li>Perfil: Tela ainda em construção.</li>
</ul>
