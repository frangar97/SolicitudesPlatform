import { UsuarioTable } from "../components/UsuarioTable";
import { useFetchUsuario } from "../hooks/useFetchUsuario";

export const UsuarioPage = () => {
    const { usuarios } = useFetchUsuario();

    return (
        <>
            <UsuarioTable usuarios={usuarios} />
        </>
    )
}