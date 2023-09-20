import { useRef } from 'react';
import './styles.css';
import { HiMagnifyingGlass } from 'react-icons/hi2';

interface NavbarPros {
    onSearch: (result: string) => void;
}

function Navbar({onSearch} : NavbarPros){

    const inputProd = useRef<HTMLInputElement>(null)

    const handleOnSearch = () => {
        if (inputProd.current && inputProd.current.value.trim() !== '') {
            onSearch(inputProd.current.value);
          }
    }

    return(
        <nav className="box cta">
            <div className="field has-addons">
                <div className="control">
                    <input className="input" type="search" placeholder="" ref={inputProd} />
                </div>
                <div className="control">
                    <button className="button button-shipping is-info" onClick={handleOnSearch}>Pesquisar&nbsp;<HiMagnifyingGlass /></button>
                </div>
            </div>
        </nav>
    )

}

export default Navbar;