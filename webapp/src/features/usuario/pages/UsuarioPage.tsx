import { useEffect, useState } from "react"
import { IUsuario } from "../interface/IUsuario";
import axios from "axios";
import { APIURL } from "../../../constants";
import { UsuarioTable } from "../components/UsuarioTable";

export const UsuarioPage = () => {
    const [usuarios, setUsuarios] = useState<IUsuario[]>([]);

    const obtenerUsuarios = async () => {
        try {
            const request = await axios.get<IUsuario[]>(`${APIURL}/api/usuario`, { headers: { Authorization: `Bearer ${localStorage.getItem("token")}` } });
            setUsuarios(request.data);
        } catch (err) {

        }
    }

    useEffect(() => {
        obtenerUsuarios();
    }, []);

    return (
        <>
            <UsuarioTable usuarios={usuarios} />
        </>
    )
}