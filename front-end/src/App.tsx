import { useEffect, useRef, useState } from 'react';
import './App.css';
import Header from './Header';
import Navbar from './Navbar';
import Section from './Section';
import { Product } from './Section/types';

function App() {
  const inputProd = useRef<HTMLInputElement>(null)
    const [produtos, setProdutos] = useState<Array<Product>>();
    async function buscarProdutos(nome:string){
        
            await fetch(`https://localhost:7199/Produto/BuscarProdutos?nome=${nome}`).then((data) => {
              return data.json()
            }).then((response) => {
                setProdutos(response);
            })
    }

  return (
    <div>
      <Header />
      <nav className="box cta">
            <div className="field has-addons">
                <div className="control">
                    <input className="input" type="search" placeholder="" ref={inputProd} />
                </div>
                <div className="control">
                    <button className="button button-shipping is-info" onClick={() => buscarProdutos(inputProd.current?.value as string)}>Pesquisar</button>
                </div>
            </div>
        </nav>
      {produtos && <Section products={produtos} />}
    </div>
  );
}

export default App;