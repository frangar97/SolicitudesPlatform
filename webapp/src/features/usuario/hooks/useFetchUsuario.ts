import { useEffect, useState } from "react";
import { IUsuario } from "../interface/IUsuario";
import { solicitudApi } from "../../../helpers/client";

export const useFetchUsuario = () => {
    const [usuarios, setUsuarios] = useState<IUsuario[]>([]);

    const obtenerUsuarios = async () => {
        try {
            const request = await solicitudApi.get<IUsuario[]>(`/api/usuario`);
            setUsuarios(request.data);
        } catch (err) {

        }
    }

    useEffect(() => {
        obtenerUsuarios();
    }, []);


    return {
        usuarios,
    }
}