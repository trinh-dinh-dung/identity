import { lazy } from "react";

export const compData = [
    {
        path: '/trang-chu',
        compPath: lazy(() => import("./components/page/Home/index"))
    },
     
]