import './styles.css';
import SectionCard from "./SectionCard";
import { Product } from "./types";

type Props = {
    products: Product[];
}

function Section( {products} : Props ){

    return(
        <section className="container">
            <div className="columns books">
            {products.map(product => (
                <SectionCard
                key={product.id} 
                product={product}
                />
                ))}
            </div>
        </section>
    )

}

export default Section;