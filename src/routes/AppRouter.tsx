import {
    createBrowserRouter,
    createRoutesFromElements, Navigate,
    Route,
    RouterProvider,
} from "react-router-dom";
import MainLayout from "../layouts/MainLayout.tsx";
import GenerationPage from "../pages/GenerationPage.tsx";

const router = createBrowserRouter((
    createRoutesFromElements(
            <Route path="/" element={<MainLayout/>}>
                <Route index element={<Navigate to={"/metiers"}/>} />
                <Route path="metiers" element={<GenerationPage/>} />
                <Route path="test" element={<h1>Test page</h1>} />
                <Route path="*" element={<h1>An error occured</h1>} />
            </Route>
    )
))

const AppRouter = () => {
    return <RouterProvider router={router}/>;
}

export default AppRouter;