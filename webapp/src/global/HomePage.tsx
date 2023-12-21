import { useEffect, useState } from "react"
import { ISolicitudCantidadEstado } from "./interface/ISolicitudCantidadEstado";
import { solicitudApi } from "../helpers/client";
import { handleError } from "../helpers/handle_error";

export const HomePage = () => {
    const [estado, setEstado] = useState<ISolicitudCantidadEstado>({ pendientes: 0, canceladas: 0, aprobadas: 0 });

    const obtenerEstadoSolicitudes = async () => {
        try {
            const request = await solicitudApi.get<ISolicitudCantidadEstado>("/api/solicitud/cantidadporestado");
            setEstado(request.data);
        } catch (err) {
            handleError(err);
        }
    }

    useEffect(() => {
        obtenerEstadoSolicitudes();
    }, []);

    return (
        <div className="row">
            <div className="col">
                <div className="card">
                    <div className="card-body">
                        <h5 className="card-title text-success">Aprobadas</h5>
                        <p className="card-text">{estado.aprobadas}</p>
                    </div>
                </div>
            </div>
            <div className="col">
                <div className="card">
                    <div className="card-body">
                        <h5 className="card-title text-danger">Canceladas</h5>
                        <p className="card-text">{estado.canceladas}</p>
                    </div>
                </div>
            </div>
            <div className="col">
                <div className="card">
                    <div className="card-body">
                        <h5 className="card-title text-warning">Pendientes</h5>
                        <p className="card-text">{estado.pendientes}</p>
                    </div>
                </div>
            </div>
        </div>
    )
}