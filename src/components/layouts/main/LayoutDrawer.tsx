import { List, ListItem } from "@mui/material";
import CreateRoundedIcon from "@mui/icons-material/CreateRounded";
import logo from '../../../assets/siepLogo.png';
import {
    StyledDrawer,
    StyledToolbar,
    StyledListItemButton,
    StyledListItemIcon,
    StyledListItemText, StyledLogo
} from './LayoutDrawer.styles.ts';
import useNavigation from "../../../hooks/useNavigation.ts";

const LayoutDrawer = () => {
    const { selectedIndex, handleNavigation } = useNavigation(0);

    const menuItems = [
        { text: "Métiers", path: "/metiers" },
        { text: "Test", path: "/test" },
    ];

    return (
        <StyledDrawer variant="permanent">
            <StyledToolbar>
                <StyledLogo src={logo} alt="logo" />
            </StyledToolbar>
            <List>
                {menuItems.map((item, index) => (
                    <ListItem key={item.text} disablePadding>
                        <StyledListItemButton selected={selectedIndex === index} onClick={() => handleNavigation(index, item.path)}>
                            <StyledListItemIcon selected={selectedIndex === index}>
                                <CreateRoundedIcon />
                            </StyledListItemIcon>
                            <StyledListItemText primary={item.text} />
                        </StyledListItemButton>
                    </ListItem>
                ))}
            </List>
        </StyledDrawer>
    );
};

export default LayoutDrawer;
