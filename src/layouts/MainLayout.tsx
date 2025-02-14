import {Outlet} from "react-router-dom";
import {Container, MainContent} from './MainLayout.styles.ts';
import LayoutAppBar from "../components/layouts/main/LayoutAppBar.tsx";
import LayoutDrawer from "../components/layouts/main/LayoutDrawer.tsx";

const MainLayout = () => {
    return (
        <Container>
            <LayoutAppBar/>
            <LayoutDrawer/>
            <MainContent component="main">
                <Outlet/>
            </MainContent>
        </Container>
    );
};

export default MainLayout;