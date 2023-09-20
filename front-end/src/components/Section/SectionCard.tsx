import { formatPrice } from './helpers';
import { Product } from './types';

type Props = {
    product: Product;
}

function SectionCard({ product }: Props) {

    return (
       <div className='column is-3'>
            <div className="card is-shady">
                <div className="card-image">
                    <figure className="image is-4by3">
                        <img src={product.thumbnail} className="modal-button" alt={product.thumbnail} />
                    </figure>
                </div>
                <div className="card-content">
                <div className="content book" data-id="${product.id}">
                    <div className="book-meta">
                        <p className="is-size-4">{formatPrice(product.preco)}</p>
                        <p className="is-size-9">ID: {product.id}</p>
                        <p className="is-size-6">Disponível em estoque: <span id="Quantidade${product.id}">{product.quantidadeDisponivel}</span></p>
                        <h4 className="is-size-5 title">{product.nome}</h4>
                    </div>
                    <a href={product.url} target='_blank'><button className="button button-buy is-success is-fullwidth"  data-id="${product.id}">Comprar</button></a>
                </div>
            </div>
            </div>
       </div>
    )

}

export default SectionCard;