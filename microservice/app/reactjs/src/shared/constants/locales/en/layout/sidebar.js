export const sidebar = {
    language: "en",
    sidebarItem: {
        homePage: 'Home page',
        administration: {
            title: 'Administration',
            decentralization: 'Decentralization',
            approve: 'Approve',
            approvalProcess: 'Approval Process',
            approveInfo: 'Approval Information',
        },

        productManagement: {
            title: 'Production manager',
            baseInfomation: {
                title: 'General data',
                workarea: 'Production Center',
                linkingProcessWithArea: 'Linking production and process centers',
                workCalendar: 'Calendar',
                productionProcess: 'Production process',
                bom: 'Bom',
                sop: 'Sop',
                colectInfomation: 'Collected data',
            },
            productPlan: {
                title: 'Production plan',
                productionOrder: 'Production requirements',
                makePlanProduction: 'Production planning',
                remakePlanProduction: 'Rescheduling production',
            },
            coordinateProduction: {
                title: 'Production Coordinator',
                productionOrder: 'Production requirements',
            },
            activeProduction: {
                title: 'Production Execution',
                product: 'Product',
                nameTheProduct: 'Product identifier',
                recordResult: 'Record the results',
                paking: 'Packing',
                recordError: 'Error recording',
            },
        },
        warehouseManagement: {
            title: 'Inventory management',
            baseInfomation: {
                title: 'General data',
                machine: 'Machine',
                location: 'Location',
                movementType: 'Movement type',
                accessories: 'Accessory',
                unit: 'Unit',
                partner: 'Đối tác',
                package: 'Package',
                standardPackage: 'Standard packing',
                packageType: 'Packing type',
                productSource: 'Source of export request - warehouse transfer',
            },
            podo: {
                title: 'PO/DO',
                po: 'package order PO',
                do: 'Delivery order DO'
            },
            storePackage: {
                title: 'warehouse packageing',
                takingPackage: 'Receive package',
                createTicketStorePackage: 'Create a ticket packing',
                storePackageIntoWarehouse: 'Store the received goods in the warehouse'
            },
            changeWarehouse: {
                title: 'Warehouse transfer',
                changeWarehouse: 'Delivery within the warehouse',
            },
            exportPackage: {
                title: 'Warehouse export',
                packageOrderMove: 'Manage export - transfer requests',
                moveOrderTicket: 'Export note - warehouse transfer',
                movePackageByTicket: 'Export - transfer warehouse according to voucher'
            },
            checking: {
                title: 'Inventory / tally',
                checking: 'Inventory / tally',
                doingChecking: 'Perform inventory / tally',
            },
            report: {
                title: 'Report',
                inventoryReport: 'Existence period report',
                inventoryReportWH: 'Inventory report',
            },
        },
    }
};
