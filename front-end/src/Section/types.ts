export type Product = {
    id: string,
    nome: string,
    preco: number,
    quantidadeDisponivel: number,
    url: string,
    thumbnail: string
}

export type OrderLocationData = {
    latitude: number;
    longitude: number;
    address: string;
}

type ProductId = {
    id: number;
}

export type OrderPayload = {
    products: ProductId[];
} & OrderLocationData;