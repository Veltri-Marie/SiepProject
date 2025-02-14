import {
    createBrowserRouter,
    createRoutesFromElements,
    Route,
    RouterProvider,
} from "react-router-dom";
import MainLayout from "../layouts/MainLayout.tsx";
import PermanentDrawerLeft from "../components/Mui/PermanentDrawer.tsx";

const router = createBrowserRouter((
    createRoutesFromElements(
            <Route path="/" element={<MainLayout/>}>  {/* Toutes les routes enfants auront ce layout */}
                <Route index element={<p>Empty page</p>} />  {/* Page desservie lorsque le chemin est vide xxx/ */}
                <Route path="metiers" element={<PermanentDrawerLeft/>} />
                <Route path="test" element={<h1>Test page</h1>} />
                <Route path="*" element={<h1>An error occured</h1>} />
            </Route>
    )
))

const AppRouter = () => {
    return <RouterProvider router={router}/>;
}

export default AppRouter;