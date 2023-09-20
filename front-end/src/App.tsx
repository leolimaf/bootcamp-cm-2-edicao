import { useState } from 'react';
import './App.css';
import Header from './components/Header';
import Navbar from './components/Navbar';
import Section from './components/Section';
import { Product } from './components/Section/types';

function App() {
  
    const [produtos, setProdutos] = useState<Array<Product>>();

    async function buscarProdutos(nome:string){
        
      await fetch(`https://localhost:7199/Produto/BuscarProdutosPorNome?nome=${nome}`).then((data) => {
        return data.json()
      }).then((response) => {
          setProdutos(response);
      })
    }

  return (
    <div>
      <Header />
      <Navbar onSearch = {buscarProdutos} />
      {produtos && <Section products={produtos} />}
    </div>
  );
}

export default App;