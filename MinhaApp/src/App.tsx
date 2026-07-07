import { useEffect, useState } from "react";
import axios from "axios";
import "./App.css";


interface Pessoa {

  id:number;
  nome:string;
  idade:number;

}


interface Transacao {

  id:number;
  descricao:string;
  valor:number;
  tipo:string;
  pessoa:string;

}



function App(){


const api = import.meta.env.VITE_API_URL || "http://localhost:5142/api";


const [pessoas,setPessoas]=useState<Pessoa[]>([]);

const [transacoes,setTransacoes]=useState<Transacao[]>([]);



const [nome,setNome]=useState("");

const [idade,setIdade]=useState(0);



const [descricao,setDescricao]=useState("");

const [valor,setValor]=useState(0);

const [tipo,setTipo]=useState("Despesa");

const [pessoaId,setPessoaId]=useState(0);




function carregar(){


axios.get(`${api}/Pessoas`)
.then(res=>setPessoas(res.data));


axios.get(`${api}/Transacoes`)
.then(res=>setTransacoes(res.data));


}



useEffect(()=>{

carregar();

},[]);





function cadastrarPessoa(){


axios.post(`${api}/Pessoas`,
{
nome,
idade
})
.then(()=>{

setNome("");

setIdade(0);

carregar();

});


}




function excluirPessoa(id:number){


axios.delete(`${api}/Pessoas/${id}`)
.then(()=>{

carregar();

});


}





function cadastrarTransacao(){


axios.post(`${api}/Transacoes`,
{
descricao,
valor,
tipo,
pessoaId
})
.then(()=>{


setDescricao("");

setValor(0);

setPessoaId(0);


carregar();


});


}




function excluirTransacao(id:number){


axios.delete(`${api}/Transacoes/${id}`)
.then(()=>{

carregar();

});


}





const receitas =
transacoes
.filter(t=>t.tipo==="Receita")
.reduce((a,b)=>a+b.valor,0);



const despesas =
transacoes
.filter(t=>t.tipo==="Despesa")
.reduce((a,b)=>a+b.valor,0);



const saldo=receitas-despesas;




return (

<div className="container">


<h1>
Controle de Gastos Residenciais
</h1>




<div className="cards">


<div className="card resumo receita">

<h3>
Receitas
</h3>

<p>
R$ {receitas}
</p>

</div>



<div className="card resumo despesa">

<h3>
Despesas
</h3>

<p>
R$ {despesas}
</p>

</div>




<div className="card resumo saldo">

<h3>
Saldo
</h3>

<p>
R$ {saldo}
</p>

</div>


</div>





<div className="card">


<h2>
Cadastro de Pessoas
</h2>


<input

placeholder="Nome"

value={nome}

onChange={e=>setNome(e.target.value)}

/>


<input

type="number"

placeholder="Idade"

value={idade}

onChange={e=>setIdade(Number(e.target.value))}

/>



<button onClick={cadastrarPessoa}>

Cadastrar Pessoa

</button>





<table>


<thead>

<tr>

<th>ID</th>

<th>Nome</th>

<th>Idade</th>

<th>Ação</th>

</tr>

</thead>



<tbody>


{
pessoas.map(p=>(

<tr key={p.id}>

<td>{p.id}</td>

<td>{p.nome}</td>

<td>{p.idade}</td>


<td>

<button
onClick={()=>excluirPessoa(p.id)}
>

Excluir

</button>


</td>


</tr>


))

}


</tbody>


</table>



</div>







<div className="card">


<h2>
Cadastro de Transação
</h2>



<input

placeholder="Descrição"

value={descricao}

onChange={e=>setDescricao(e.target.value)}

/>



<input

type="number"

placeholder="Valor"

value={valor}

onChange={e=>setValor(Number(e.target.value))}

/>



<select

value={tipo}

onChange={e=>setTipo(e.target.value)}

>


<option>
Despesa
</option>


<option>
Receita
</option>


</select>





<select

value={pessoaId}

onChange={e=>setPessoaId(Number(e.target.value))}

>


<option value="0">

Escolha a pessoa

</option>



{

pessoas.map(p=>(

<option

key={p.id}

value={p.id}

>

{p.nome}

</option>


))


}


</select>



<button onClick={cadastrarTransacao}>

Cadastrar

</button>



</div>







<div className="card">


<h2>
Transações
</h2>


<table>


<thead>

<tr>

<th>ID</th>

<th>Descrição</th>

<th>Valor</th>

<th>Tipo</th>

<th>Pessoa</th>

<th>Ação</th>


</tr>

</thead>


<tbody>


{

transacoes.map(t=>(


<tr key={t.id}>


<td>{t.id}</td>

<td>{t.descricao}</td>

<td>R$ {t.valor}</td>

<td>{t.tipo}</td>

<td>{t.pessoa}</td>


<td>


<button
onClick={()=>excluirTransacao(t.id)}
>

Excluir

</button>


</td>



</tr>


))


}



</tbody>


</table>


</div>



</div>


)


}


export default App;