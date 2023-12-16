import { useEffect, useState } from "react";
import { APIURL } from "../../../constants";
import axios from "axios";
import { ITipoSolicitud } from "../interface/ITipoSolicitud";

export const useFetchTipoSolicitud = () => {
    const [tiposSolicitud, setTiposSolicitud] = useState<ITipoSolicitud[]>([]);

    const obtenerTipoSolicitudes = async () => {
        try {
            const request = await axios.get<ITipoSolicitud[]>(`${APIURL}/api/solicitud/tipos`, { headers: { Authorization: `Bearer ${localStorage.getItem("token")}` } });
            setTiposSolicitud(request.data);
        } catch (err) {

        }
    }

    useEffect(() => {
        obtenerTipoSolicitudes();
    }, []);

    return {
        tiposSolicitud,
        setTiposSolicitud,
    }
}