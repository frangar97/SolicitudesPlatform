import axios from "axios"

export const handleError = (err: any) => {
    if (axios.isAxiosError(err)) {
        if (err.response) {
            alert(err.response.data["detail"]);
            return;
        }
    }

    alert("Ha ocurrido un error y no se pudo realizar la accion");
}